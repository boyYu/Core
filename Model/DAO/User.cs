namespace Model.DAO
{
    /// <summary>
    /// 人员
    /// </summary>
    public class User:Base
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
