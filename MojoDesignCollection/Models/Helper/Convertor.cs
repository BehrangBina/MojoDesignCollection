using System;

namespace MojoDesignCollection.Models.Helper
{
    public class Convertor
    {
        public static CategoryEnum StringToCategoryEnum (string enumString)
        {
            return Enum.TryParse(enumString, true, out CategoryEnum categoryEnum) ? categoryEnum : CategoryEnum.All;
        }
    }
}
