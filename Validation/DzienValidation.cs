using System;

namespace KinoDotNetCore.Validation
{
    public class DzienValidation
    {
        private const int dayPartLength = 2;
        private const int monthPartLength = 2;
        private const int yearPartLength = 4;

        public bool IsValid(string day)
        {
            var firstDelimiter = day.IndexOf('-');
            var secondDelimiter = day.LastIndexOf('-');

            if (firstDelimiter == -1 || secondDelimiter == -1)
                throw new ArgumentException();

            var firstPart = day.Substring(0, firstDelimiter);
            if (firstPart.Length != dayPartLength)
                return false;

            var tempPart = day.Remove(0, dayPartLength + 1);
            var middlePart = tempPart.Substring(0, tempPart.IndexOf('-'));
            if (middlePart.Length != monthPartLength)
                return false;

            var lastPart = day.Substring(secondDelimiter + 1);
            if (lastPart.Length != yearPartLength)
                return false;

            if (Int32.Parse(firstPart) > 31 || Int32.Parse(firstPart) < 1)
                return false;

            if (Int32.Parse(middlePart) > 12 || Int32.Parse(middlePart) < 1)
                return false;

            if (Int32.Parse(lastPart) < 2020)
                return false;

            if (Int32.Parse(firstPart) == 31)
            {
                if (Int32.Parse(middlePart) == 2 || Int32.Parse(middlePart) == 4 || Int32.Parse(middlePart) == 6
                    || Int32.Parse(middlePart) == 9 || Int32.Parse(middlePart) == 11)
                    return false;
            }
            if (Int32.Parse(firstPart) > 29 && Int32.Parse(middlePart) == 2)
                return false;

            return true;
        }
    }
}
