namespace ItemCodes.Console
{
    public class BoqItemCodeFirstSection : BoqItemCodeSection
    {
        public override double Value
        {
            get
            {
                var first = _content.Substring(0, 1).ToUpper()[0] - 'A' + 1;
                var rest = double.Parse(_content.Substring(1, _content.Length - 1));
                return first * rest;
            }
        }

        protected override bool IsValid(string value)
        {
            if (value.Length != 7 && value.Length != 4)
            {
                return false;
            }

            var uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (!uppers.Contains(value[0]))
            {
                return false;
            }

            if (!double.TryParse(value.Substring(1, value.Length - 1), out var result))
            {
                return false;
            }

            return true;
        }
    }
}