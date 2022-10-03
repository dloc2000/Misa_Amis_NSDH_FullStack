var MISAResource = {

    /**
     * Câu cảnh báo cho người dùng nếu nhập thiếu trường quan trọng
     * Author: DXLOC 15/09/2022
     */
    ErrorValidate: {
        EmployeeCodeNotEmpty: {
            VI: "Mã nhân viên không được phép để trống",
            EN: "Employee Code is not empty"
        },
        FullNameNotEmpty: {
            VI: "Tên không được phép để trống",
            EN: "Full name not Empty."
        },
        DepartmentNotEmpty: {
            VI: "Đơn vị không được phép để trống",
            EN: "Department not Empty."
        },
      
    },

    /**
     * Câu thông báo cho người dùng 
     * Author: DXLOC 15/09/2022
     */
    MessageDialog: {
        success: {
            VI: "Thành công",
            EN:  "Success"
        },
        error: {
            VI: "Đã xảy ra lỗi vui lòng liên hệ CSKH Misa để được hỗ trợ",
            EN: "An error has occurred, please contact Misa Customer Service for support"
        },
        exists: {
            VI: "Mã nhân viên đã tồn tại trong hệ thống",
            EN: "Employee code already exists in the system"
        },
        confirm: {
            VI: "Dữ liệu đã bị thay đổi bạn có muốn cất không?",
            EN: "The data has been changed do you want to save it?"
        },
        delete: {
            VI: "Bạn có thực sự muốn xóa nhân viên không?",
            EN: "Do you really want to delete the employee ?"
        },
        deletes: {
            VI: "Bạn có thực sự muốn xóa những nhân viên này không?",
            EN: "Do you really want to bulk delete employees?"
        }
    }

}
export default MISAResource;