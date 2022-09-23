 var common = {
  /**
   * Định dạng ngày tháng năm sinh trên client
   * @param {any} -  ngày tháng
   * Author: Locdx 20/09/2022
   */
  formatDate(date) {
    try {
      if (date) {
        date = new Date(date);
        // Lấy ra ngày , ngày < 10 sẽ có dạng 01,02,...
        let day = date.getDate();
        day = day < 10 ? `0${day}` : day;
        // Lấy ra tháng, tháng < 10 sẽ có dạng 01 ,02,...
        let month = date.getMonth() + 1;
        month = month < 10 ? `0${month}` : month;
        // Lấy ra năm
        let year = date.getFullYear();
        return `${day}/${month}/${year}`;
      } else {
        return " ";
      }
    } catch (error) {
      console.log(error);
    }
  },
   /**
   * Định dạng ngày tháng năm sinh xuống database
   * @param {any} -  ngày tháng
   * Author: Locdx 20/09/2022
   */
  formatDate2(date) {
    try {
      if (date) {
        date = new Date(date);
        // Lấy ra ngày , ngày < 10 sẽ có dạng 01,02,...
        let day = date.getDate();
        day = day < 10 ? `0${day}` : day;
        // Lấy ra tháng, tháng < 10 sẽ có dạng 01 ,02,...
        let month = date.getMonth() + 1;
        month = month < 10 ? `0${month}` : month;
        // Lấy ra năm
        let year = date.getFullYear();
        var dateConvert = year + "-" + month + "-" + day;
        return dateConvert;
      } else {
        return " ";
      }
    } catch (error) {
      console.log(error);
    }
  },
};

export default common;