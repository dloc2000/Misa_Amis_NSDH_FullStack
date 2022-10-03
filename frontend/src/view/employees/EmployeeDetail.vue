<template>
  <div
    tabindex="0"
    id="formEmployee"
    class="dialog"
    @keyup.esc.exact="clickConfirmHideForm"
  >
    <m-form :height="610" @submit.prevent="clickAddEmployee">
      <template #header>
        <div class="form__popup-title">
          <div class="title-popup">Thông tin nhân viên</div>
          <div class="checkbox__component">
            <MCheckbox :idCheckbox="'customer'" />
            <label for="customer" value="1">Là khách hàng</label>
          </div>
          <div class="checkbox__component">
            <MCheckbox :idCheckbox="'supplier'" />
            <label for="supplier" value="1">Là nhà cung cấp</label>
          </div>
        </div>
        <div class="form__popup-close">
          <div class="btn-help m__icon-help"></div>
          <div
            class="btn-close m__icon-close"
            @click="clickConfirmHideForm"
          ></div>
        </div>
      </template>

      <template #content>
        <div class="form__grid-up col-2">
          <div class="grid__up-left row-3">
            <div class="left-1">
              <div class="group__input--title">
                <div class="input__title">
                  Mã
                  <b style="color: red">*</b>
                </div>
                <MInput
                  firstFocus
                  :rules="'required'"
                  v-model="employee.EmployeeCode"
                  v-model:errMsg="errors[0]"
                  fieldName="Mã nhân viên"
                />
              </div>
              <div class="group__input--title">
                <div class="input__title">
                  Tên
                  <b style="color: red">*</b>
                </div>
                <MInput
                  :rules="'required'"
                  v-model="employee.FullName"
                  v-model:errMsg="errors[1]"
                  fieldName="Họ và tên"
                />
              </div>
            </div>
            <div class="left-2">
              <div class="group__input--title">
                <div class="input__title">
                  Đơn vị
                  <b style="color: red">*</b>
                </div>
                <MComboboxDepartment v-model:departmentID="employee.DepartmenId" v-model:departmentCode="employee.DepartmentCode"
                v-model:departmentName="employee.DepartmentName" v-model:depError="errors[2]"/>
              </div>
            </div>
            <div class="left-3">
              <div class="group__input--title">
                <div class="input__title">Chức danh</div>
                <div class="combobox" style="width: 100%">
                  <input type="text" class="input input-full-width" v-model="employee.PositionName">
                  <button @click="isShowPosition=!isShowPosition" tabindex="-1">
                    <div class="icon"></div>
                  </button>
                  <div class="combobox__data-under" v-if="isShowPosition">
                      <div class="combobox__item" v-for="(item,id) in positions" :key="id" :class="{'combobox__item-selected': item.PositionId == idPos }" @click="onSelectPosition(item)">{{item.PositionName}}</div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="grid__up-right row-3">
            <div class="right-1">
              <div class="group__input--title">
                <div class="input__title">Ngày sinh</div>
                <MInput
                  v-model="dateTrungGian"
                  :type="'date'"
                  :classInput="['input-full-width']"
                />
              </div>
              <div class="group__input--title">
                <div class="input__title" style="margin-left: 5px">
                  Giới tính
                </div>
                <MInputRadioVue
                  :listOptions="listGender"
                  v-model="employee.Gender"
                  fieldName="Gender"
                />
              </div>
            </div>
            <div class="right-2">
              <div class="group__input--title">
                <div class="input__title">Số CMND</div>
                <MInput v-model="employee.IdentityNumber"/>
              </div>
              <div class="group__input--title">
                <div class="input__title">Ngày cấp</div>
                <MInput
                  v-model="employee.IdentityDate"
                  :type="'date'"
                  :classInput="['input-full-width']"
                />
              </div>
            </div>
            <div class="right-3">
              <div class="group__input--title">
                <div class="input__title">Nơi cấp</div>
                <MInput
                  v-model="employee.IdentityPlace"
                  :classInput="['input-full-width']"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="form__grid-down row-3">
          <div class="grid__down-1">
            <div class="group__input--title">
              <div class="input__title">Địa chỉ</div>
              <MInput :classInput="['input-full-width']" v-model="employee.Address"/>
            </div>
          </div>
          <div class="grid__down-2">
            <div class="group__input--title">
              <div class="input__title">ĐT di động</div>
              <MInput v-model="employee.PhoneNumber" />
            </div>
            <div class="group__input--title">
              <div class="input__title">ĐT cố định</div>
              <MInput />
            </div>
            <div class="group__input--title">
              <div class="input__title">Email</div>
              <MInput v-model="employee.Email"/>
            </div>
          </div>
          <div class="grid__down-2 col-3">
            <div class="group__input--title">
              <div class="input__title">Tài khoản ngân hàng</div>
              <MInput v-model:value="employee.BankAccountNumber" />
            </div>
            <div class="group__input--title">
              <div class="input__title">Tên ngân hàng</div>
              <MInput v-model:value="employee.BankAccountName"/>
            </div>
            <div class="group__input--title">
              <div class="input__title">Chi nhánh</div>
              <MInput v-model:value="employee.BankBranch"/>
            </div>
          </div>
        </div>
      </template>

      <template #footer>
        <div class="group__button-left">
          <MButton
            :classBtn="'button2'"
            :text="'Hủy'"
            @click.esc="clickCancel"
          />
        </div>
        <div class="group__button-right">
          <MButton :classBtn="'button2 button__save'" :text="'Cất'" @click="clickSaveEmployee"/>
          <MButton
            :classBtn="'button1'"
            :text="'Cất và thêm'"
            @click.enter="clickAddEmployee"
          />
        </div>
      </template>
    </m-form>
    <MPopup
      v-if="isShowPopup"
      @close-popup="isShowPopup = false"
      :message="messageError"
    />
  </div>
</template>

<script>
import MDialog from "@/components/base/dialog/MDialog.vue";
import MButton from "@/components/base/button/MButton.vue";
import MCheckbox from "@/components/base/checkbox/MCheckbox.vue";
import { HTTP } from "@/api/http-common";
import common from "@/common/common.js";

/**
 * Bảng chi tiết thông tin nhân viên
 * Author : Locdx 13/09/2022
 */

export default {
  name: "EmployeeDetail",
  props: {
    // ẩn/hiện form
    isShowFormParent: {
      default: false,
    },
    // nhân vien đc chọn
    employeeSelected: Function,
    formMode: {
      type: Number,
      default: 1,
    },
  },
  data() {
    return {
      // mảng nhân viên
      employee: {},
      // giá trị 
      value: null,
      // ẩn hiện popup
      isShowPopup: false,
      // ẩn/hiện chức vụ
      isShowPosition: false,
      // chức vụ
      positions: {},
      // danh sách giới tính
      listGender: [
        { Name: "Nam", Value: 1 },
        { Name: "Nữ", Value: 2 },
        { Name: "Khác", Value: 0 },
      ],
      // tên lỗi
      messageError: "",
      //mảng lỗi
      errors: [],
      // convert ngày
      dateTrungGian: "",
      // id chức vụ
      idPos: 0
    };
  },
  components: { MDialog, MButton, MCheckbox },
  created() {
    this.employeeSelected.DateOfBirth = common.formatDate2(
      this.employeeSelected.DateOfBirth
    );
    this.employee = this.employeeSelected;
    this.getAllPosition();
    this.dateTrungGian = this.employeeSelected.DateOfBirth;
  },
  watch: {
    dateTrungGian(newval, oldval) {
      if (newval != oldval) {
        this.employee.DateOfBirth = this.sliceString(newval);
      }
    },
  },
  methods: {
    /**
     * Click sửa , thêm nhân viên
     * Author : Locdx 13/09/2022
     */
    clickAddEmployee() {
      try {
        // validate dữ liệu
        if (!this.errors.every(item => !item)) {
          // lấy ra phần tử lỗi đầu tiên
          this.messageError = this.errors.find(item => item);
          // nếu có lỗi bật popup cảnh báo
          if (this.messageError) {
            this.isShowPopup = true;
            return;
          }
        }
        console.log(this.employee)

        // Cất dữ liệu
        // Thêm mới - formMode = 1
        if (this.formMode == 1) {
          HTTP.post(`/employees`, this.employee)
            .then((response) => {
              this.$emit("hide-form");
              this.$emit("load-data");
              this.$emit("load-toast");
            })
            .catch((error) => {
              console.log(error);
            });
        // Sửa - formMode = 2
        } else if (this.formMode == 2) {
          HTTP.put(`/employees/${this.employee.EmployeeID}`, this.employee)
            .then((res) => {
              this.$emit("hide-form");
              this.$emit("load-data");
              this.$emit("load-toast");
            })
            .catch();
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Click thêm mới / sửa nhân viên
     * Author : Locdx 13/09/2022
     */
    clickSaveEmployee() {
        this.clickAddEmployee();
    },
    /**
     * Click ẩn form nhân viên
     * Author : Locdx 13/09/2022
     */
    clickHideForm() {
      this.$emit("hide-form");
    },
    clickConfirmHideForm() {
      this.$emit("confirm-form");
    },
    /**
     * Click hủy sẽ đóng form nhân viên
     * Author : Locdx 13/09/2022
     */
    clickCancel() {
      this.$emit("hide-form", false);
    },
    /**
     * Check object null và undefined
     * Author : Locdx 21/09/2022
     */
    objectIsEmpty(obj) {
      return (
        obj &&
        Object.keys(obj).length === 0 &&
        Object.getPrototypeOf(obj) === Object.prototype
      );
    },
    /**
     * Chuỗi định dạng ngày dưới database
     * Author : Locdx 21/09/2022
     */
    sliceString(text) {
      return text.slice(0, 10) + "T00:00:00";
    },
    /**
     * Lấy tất cả chức vụ
     * Author : Locdx 23/09/2022
     */
    getAllPosition() {
        try {
            HTTP.get(`/Positions`)
            .then((res) => {
              console.log("pos" , res.data)
                this.positions = res.data
            })
        } catch (error) {
          console.log(error);
        }
    },
    /**
     * chọn chức vụ
     * Author: Locdx 23/09/2022
     */
    onSelectPosition(pos) {
        this.idPos = pos.PositionId
        this.isShowPosition = false;
        this.employee.PositionName = pos.PositionName
        this.employee.PositionID = pos.PositionId
    }
  },
};
</script>

<style></style>
