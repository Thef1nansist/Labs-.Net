using System;

namespace Task3
{
    public struct Key : IComparable<Key>
    {
        private readonly Note _note;
        private readonly Accidental _accidental;
        private readonly Octave _octave;

        public Key(Note note, Accidental accidental, Octave octave)
        {
            _note = note;
            _accidental = accidental;
            _octave = octave;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Key key)
            {
                return false;
            }

            var tonFirst = (int)_note + (int)_accidental + (int)_octave;
            var tonSecond = (int)key._note + (int)key._accidental + (int)key._octave;

            return tonSecond == tonFirst;
        }

        public override int GetHashCode() => new Key(_note, _accidental, _octave).GetHashCode();

        public override string ToString()
        {
            var symbol = "";

            if(_accidental == Accidental.Flat)
            {
                symbol = "&";
            }
            else if(_accidental == Accidental.Sharp)
            {
                symbol = "#";
            }

            return $"{_note}{symbol} ({_octave})";
        }

        public int CompareTo(Key key)
        {
            var firstTon = (int)_note + (int)_accidental + (int)_octave;
            var secondTon = (int)key._note + (int)key._accidental + (int)key._octave;

            if (firstTon == secondTon)
            {
                return 0;
            }

            return firstTon > secondTon ? 1 : -1;
        }
    }
}
