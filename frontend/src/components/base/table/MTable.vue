<template>
  <div class="table__content">
    <table id="tbEmployeeList" class="table">
      <thead>
        <tr>
          <th class="text__align--center" style="min-width: 40px">
            <span class="d-flex-center"><MCheckbox/></span>
          </th>
          <th
            v-for="(item, index) in headers"
            :key="index"
            :class="item.className"
            :style="{ 'min-width': item.Width + 'px' }"
          >
            {{ item.Caption }}
          </th>
          <th class="text__align--center" style="min-width: 120px">
            Chức năng
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(emp, index) in dataSource"
          :key="emp.EmployeeId"
          :class="{ 'row--selected': index === indexRow }"
          @click="clickSelectedRow(index)"
          @dblclick="rowDoubleClick(emp)"
        >
          <td class="text__align--center"><span class="d-flex-center"><input
              class="m__checkbox-input"
              :class="{ 'checkbox-active': idActive == index }"
              type="checkbox"
              @click.stop="onCheckbox(index)"
              :value="emp"
              @dblclick="$event.stopPropagation()"
             v-model="employeesDelete"/> </span>
         </td>
          <td v-for="item in headers" :key="item.Field" :class="item.className">
            <span v-if="item.type == 1">
              {{ emp[item.Field] ? emp[item.Field] : "" }}
            </span>
            <span v-else-if="item.type == 2">
              {{ emp[item.Field] ? Common.formatDate(emp[item.Field]) : "" }}
            </span>
            <span v-else-if="item.type == 3">
              <slot name="customColumn" :data="emp[item.Field]"></slot>
            </span>
          </td>
          <td>
              <MOptions @delete="showPopupDelete(emp)"/>
          </td>
        </tr>
    
                                                <!-- <td id="EmployeeCode"class="text__align--center no_padding" style="min-width: 40px;">
                                                    <input type="checkbox">
                                                </td>
                                                <td class="text__align--left" style="min-width: 150px;">001200</td>
                                                <td class="text__align--left" style="min-width: 250px;">Nguyễn Văn Vũ</td>
                                                <td class="text__align--left" style="min-width: 120px;">Nam</td>
                                                <td class="text__align--center" style="min-width: 120px;">01/01/1990</td>
                                                <td class="text__align--left" style="min-width: 200px;">001200066666</td>
                                                <td class="text__align--left" style="min-width: 250px;">Nhân viên</td>
                                                <td class="text__align--left" style="min-width: 250px;">Nhóm kiểm hàng</td>
                                                <td class="text__align--left" style="min-width: 150px;">Số tài khoản</td>
                                                <td class="text__align--left" style="min-width: 250px;">Tên ngân hàng</td>
                                                <td class="text__align--left" style="min-width: 250px;">Chi nhánh TK ngân hàng</td>
                                                <td class="text__align--center" style="min-width: 120px;"> -->
                                              
      </tbody>
    </table>
  </div>
</template>
<script>
import common from "@/common/common.js";
export default {
  name: "MTable",
  props: {
    showCheckBox: {
      Type: Boolean,
      default: true,
    },
    dataSource: {
      Type: Array,
      default: () => [],
    },
    headers: {
      Type: Array,
      default: () => [
        {
          Caption: "Mã nhân viên",
          Field: "EmployeeCode",
          Width: 150,
          className: "text__align--left",
          type: 1, // 1- text, 2 -date, 3-datetime, 4- time
        },
        {
          Caption: "Tên nhân viên",
          Field: "FullName",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Giới tính",
          Field: "Gender",
          Width: 120,
          className: "text__align--left",
          type: 3,
        },
        {
          Caption: "Ngày sinh",
          Field: "DateOfBirth",
          Width: 120,
          className: "text__align--center",
          type: 2,
        },
        {
          Caption: "Số CMND",
          Field: "IdentityNumber",
          Width: 200,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Chức danh",
          Field: "PositionName",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Tên đơn vị",
          Field: "DepartmentName",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Số tài khoản",
          Field: "BankAccountNumber",
          Width: 150,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Tên ngân hàng",
          Field: "BankAccountName",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
        {
          Caption: "Chi nhánh TK ngân hàng",
          Field: "BankBranch",
          Width: 250,
          className: "text__align--left",
          type: 1,
        },
      ],
    },
  },
  data() {
    return {
      indexRow: 0,
      employeeSelected: {},
      Common: common,
      employeesDelete: [],
      isActive: false,
      idActive: 0
    };
  },
  computed: {
    convertGender() {
      if (true) {
      }
    },
  },
  methods: {
    /**
     * click chọn hàng của table
     * @param {index}  stt
     * Auhthor: DXLOC 15/09/2022
     */
    clickSelectedRow(index) {
      this.indexRow = index;
    },
     /**
     * Double click row sẽ hiện form sửa
     * @param {emp} đối tượng 
     * Auhthor: DXLOC 15/09/2022
     */
    rowDoubleClick(emp) {
      this.$emit("emp-selected", emp);
    },
    /**
    * hiển thi popup xóa
    * @param {*} emp 
    * Author: DXLOC 15/09/2022
    */
    showPopupDelete(emp) {
        this.emitter.emit("popup-delete" , emp);
    },
    /**
     * Chọn các ô checkbox
     * Author: DXLOC 24/09/2022
     */
    onCheckbox(index) {
      this.idActive = index
      // const employeesDelete = this.employeesDelete
      // this.emitter.emit("delete-bluk", employeesDelete)
    },
    /**
     * Lấy ra data số nhân viên đc chọn
     * Author: DXLOC 24/09/2022
     */
    getEmployeesDelete() {
        return this.employeesDelete;
    }
  },
};
</script>
<style>
@import url("@/css/components/table.css");
input[type="checkbox"] {
  /* tắt định dạng checkbox */
  appearance: none;
  -webkit-appearance: none;
  height: 20px;
  width: 20px;
  outline: none;
  background-color: #fff;
  border: 1px solid #ccc;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
}
.checkbox-active {
  border: 1px solid #2ca01c !important;
}
input[type="checkbox"]:after {
  content: "";
  font-weight: 700;
  font-size: 30px;
  background: url(@/assets/img/Sprites.64af8f61.svg) no-repeat -1294px -562px;
  width: 18px;
  height: 15px;
  /* transform: rotate(0deg); */
  display: none;
}
input[type="checkbox"]:checked:after {
  display: block;
  /* transition: all 0.2 ease;
  transform: rotate(-180deg); */
}
</style>
