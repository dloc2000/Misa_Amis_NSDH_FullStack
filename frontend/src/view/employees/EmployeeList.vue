<template>
  <div class="tag-as-parent">
    <div class="main__page">
      <div class="page__header">
        <div class="page__header-title">Nhân viên</div>
        <button id="btnAdd" class="page__header--button button1" @click="clickShowFormEmployee">
          Thêm mới nhân viên
        </button>
      </div>
      <div class="page__content">
        <div class="page__group">
          <div class="page__toolbar">
            <input type="text" class="page__toolbar--input input input-placehoder__italic"
              placeholder="Tìm theo mã, tên nhân viên" />
            <button id="btnReload" class="page__toolbar--reload" @click="clickReloadPage"></button>
            <div>
              <div class="input__icon-right"></div>
            </div>
          </div>
          <div class="page__table">
            <div class="table__content">
              <table id="tbEmployeeList" class="table">
                <thead>
                  <tr>
                      <th class="text__align--center" style="min-width: 40px">
                          <input type="checkbox"/>
                      </th>
                    <th v-for="propData in propsDataRow" :key="propData.id" :class="propData.class"
                      :style="propData.style">{{propData.name}}</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(emp, index) in employees" :key="emp.EmployeeId"
                    :class="{ 'row--selected': index === indexRow }" @click="clickSelectedRow(index)"
                    @dblclick="rowDoubleClick(emp)">
                    <td><input type="checkbox" /></td>
                    <td>{{ emp.EmployeeCode }}</td>
                    <td>{{ emp.FullName }}</td>
                    <td>{{ emp.Gender }}</td>
                    <td></td>
                    <td></td>
                    <td>{{ emp.PhoneNumber }}</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <!-- <tr class="row--selected">
                                                <td id="EmployeeCode"class="text__align--center no_padding" style="min-width: 40px;">
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
                                                <td class="text__align--center" style="min-width: 120px;">
                                                        <div class="group__title-combobox">
                                                            <div class="title">Sửa</div>
                                                            <div class="combobox">
                                                                <button class="m-icon"><div class="m-arrow-dropdown-blue"></div></button>
                                                                <div class="combobox__data-under" hidden>
                                                                    <div class="combobox__item" value="0">Nhân bản</div>
                                                                    <div class="combobox__item" value="1" id="btnDelEmp">Xóa</div>
                                                                    <div class="combobox__item"  value="2">Ngưng sử dụng</div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                </td>
                                            </tr> -->
                </tbody>
              </table>
            </div>
          </div>
        </div>
        <div class="page__footer">
          <div class="page__total-record">Tổng số:<b> 94</b> bản ghi</div>
          <div class="page__pagingation">
            <div class="combobox_paging combobox">
              <input type="text" class="input" />
              <button>
                <div class="m-arrow-dropdown"></div>
              </button>
              <div class="combobox__data-above" hidden>
                <div class="combobox__item item-left" value="0">
                  5 bản ghi trên 1 trang
                </div>
                <div class="combobox__item item-left combobox__item-selected" value="1">
                  10 bản ghi trên 1 trang
                </div>
                <div class="combobox__item item-left" value="2">
                  15 bản ghi trên 1 trang
                </div>
                <div class="combobox__item item-left" value="3">
                  20 bản ghi trên 1 trang
                </div>
              </div>
            </div>
            <div class="paging__group-button">
              <button class="paging__button button-first" disabled>Trước</button>
              <div class="button__number-group">
                <button class="paging__number button__number-selected">1</button>
                <button class="paging__number">2</button>
                <button class="paging__number">...</button>
                <button class="paging__number">4</button>
                <button class="paging__number">5</button>
              </div>
              <button class="paging__button button-last">Sau</button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <EmployeeDetail v-if="isShowForm" @hide-form="closeFormEmployee" :employeeSelected="employeeSelected" />
    <MLoading v-if="isLoading" />
  </div>
</template>

<script>
import EmployeeDetail from "./EmployeeDetail.vue";
import MLoading from "@/components/base/loading/MLoading.vue";
export default {
  name: "EmployeeList",
  created() {
    this.loadData(),
    this.addCheckbox()

  },
  props: {

  },
  methods: {
    // click reload page
    clickReloadPage() {
      this.loadData();
    },
    // click chọn hàng của table
    clickSelectedRow(index) {
      this.indexRow = index;
    },
    // click "Thêm nhân viên" và hiện form
    clickShowFormEmployee() {
      this.isShowForm = true;
      this.employeeSelected = {};
    },
    // Đóng form nhân viên
    closeFormEmployee() {
      this.isShowForm = false;
    },
    // Double click row sẽ hiện form sửa
    rowDoubleClick(emp) {
      this.employeeSelected = emp;
      this.isShowForm = true;
    },
    addCheckbox() {
      this.htmlRow.push('</br><input type="checkbox"/>')
    },
    // Load data lên table
    loadData() {
      //Loading dữ liệu
      this.isLoading = true;
      fetch("https://cukcuk.manhnv.net/api/v1/Employees", { methods: "GET" })
        .then((res) => res.json())
        .then((data) => {
          this.employees = data;
          this.isLoading = false;
        })
        .catch((error) => {
          console.log(error);
          this.isLoading = false;
        });
    },
  },
  data() {
    return {
      propsDataRow: [
        // {
        //   id: 1,
        //   class: "text__align--center",
        //   style: "min-width: 40px",
        //   name: "",

        // },
        {
          id: 2,
          class: "text__align--left",
          style: "min-width: 150px",
          name: "Mã nhân viên"
        },
        {
          id: 3,
          class: "text__align--left",
          style: "min-width: 250px",
          name: "Tên nhân viên"
        },
        {
          id: 4,
          class: "text__align--left",
          style: "min-width: 120px",
          name: "Giới tính"
        },
        {
          id: 5,
          class: "text__align--center",
          style: "min-width: 120px",
          name: "Ngày sinh"
        },
        {
          id: 6,
          class: "text__align--left",
          style: "min-width: 200px",
          name: "Số CMND"
        },
        {
          id: 7,
          class: "text__align--left",
          style: "min-width: 250px",
          name: "Chức danh"
        },
        {
          id: 8,
          class: "text__align--left",
          style: "min-width: 250px",
          name: "Tên đơn vị"
        },
        {
          id: 9,
          class: "text__align--left",
          style: "min-width: 150px",
          name: "Số tài khoản"
        },
        {
          id: 10,
          class: "text__align--left",
          style: "min-width: 250px",
          name: "Tên ngân hàng"
        },
        {
          id: 11,
          class: "text__align--left",
          style: "min-width: 250px",
          name: "Chi nhánh tài khoản ngân hàng"
        },
        {
          id: 12,
          class: "text__align--center",
          style: "min-width: 120px",
          name: "Chức năng"
        },
      ],
      employees: [],
      isLoading: false,
      indexRow: undefined,
      isShowForm: false,
      employeeSelected: {},
      htmlRow: []
    };
  },
  components: { EmployeeDetail, MLoading },
};
</script>

<style>
.tag-as-parent {
  width: 100%;
  height: 100%;
}
</style>
