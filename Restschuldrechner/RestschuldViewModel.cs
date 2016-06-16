// --------------------------------------------------------------------------------------
// <copyright file="RestschuldViewModel.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2016 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Restschuldrechner
// </summary>
// --------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Restschuldrechner
{
    public class RestschuldViewModel : INotifyPropertyChanged
    {
        private int _kreditSumme = 150000;
        private double _tilgungsSatz = 1.5f;
        private int _zinsbindung = 15;
        private double _zinsfuss = 1.5f;
        private double _zahlungen;
        private double _rsk;
        private double _tilgung;
        private double _zinszahlungen;
        private double _anteilRestschuld;
        public event PropertyChangedEventHandler PropertyChanged;

        public RestschuldViewModel()
        {
            Calculate();
        }

        /// <summary>
        /// Kreditsumme (S)
        /// </summary>
        public int KreditSumme
        {
            get { return _kreditSumme; }
            set
            {
                _kreditSumme = value;
                OnPropertyChanged();
                Calculate();
            }
        }

        /// <summary>
        /// Zinsfuß (p)
        /// </summary>
        public double Zinsfuss
        {
            get { return _zinsfuss; }
            set
            {
                _zinsfuss = value;
                OnPropertyChanged();
                Calculate();
            }
        }


        /// <summary>
        /// Tilgungsssatz (t)
        /// </summary>
        public double TilgungsSatz
        {
            get { return _tilgungsSatz; }
            set
            {
                _tilgungsSatz = value;
                OnPropertyChanged();
                Calculate();
            }
        }

        /// <summary>
        /// Zinsbindung in Jahren (k)
        /// </summary>
        public int Zinsbindung
        {
            get { return _zinsbindung; }
            set
            {
                _zinsbindung = value;
                OnPropertyChanged();
                Calculate();
            }
        }

        private void Calculate()
        {
            // Zinssatz pro Jahr (i)
            var i = Zinsfuss / 100;

            // Zinssatz pro Monat (im)
            var im = i / 12;

            // Zinsfaktor pro Monat (qm)
            var qm = im + 1;

            // Zinsbindung in Monaten
            var km = Zinsbindung * 12;

            // jährliche Anuität (A)
            var annuitaet = KreditSumme * (i + TilgungsSatz / 100);

            // monatliche Annuität (a)
            var a = annuitaet / 12;

            // Gesamtzahlungen während der Laufzeit
            Zahlungen = annuitaet * Zinsbindung;

            // Restschuld am Ende der Laufzeit / Jahr k (RSk)
            Restschuld = KreditSumme - (Math.Pow(qm, km) - 1) / im * (a - im * KreditSumme);

            // Tilgung 
            Tilgung = KreditSumme - Restschuld;
            Zinszahlungen = Zahlungen - Tilgung;

            AnteilRestschuld = 250d/KreditSumme*Restschuld;
        }

        public double AnteilRestschuld
        {
            get { return _anteilRestschuld; }
            set
            {
                _anteilRestschuld = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Summe der Zinszahlungen während der Zinsbindung
        /// </summary>
        public double Zinszahlungen
        {
            get { return _zinszahlungen; }
            set
            {
                _zinszahlungen = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Höhe der Tilgung während der Zinsbindung
        /// </summary>
        public double Tilgung
        {
            get { return _tilgung; }
            set
            {
                _tilgung = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///  Restschuld am Ende der Laufzeit
        /// </summary>
        public double Restschuld
        {
            get { return _rsk; }
            set
            {
                _rsk = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gesamtzahlungen während der Laufzeit
        /// </summary>
        public double Zahlungen
        {
            get { return _zahlungen; }
            set
            {
                _zahlungen = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}