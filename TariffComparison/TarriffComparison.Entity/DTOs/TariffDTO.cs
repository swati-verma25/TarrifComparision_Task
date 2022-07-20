namespace TarriffComparison.Entity.DTOs
{
    /// <summary>
    /// TarrifDTO for api result
    /// </summary>
    public class TariffDTO
    {
        /// <summary>
        /// name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// annualcost based ont he consumption
        /// </summary>
        public double AnnualCosts { get; set; }
    }
}
