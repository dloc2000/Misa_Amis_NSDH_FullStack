<template>
  <div
    tabindex="0"
    id="formEmployee"
    class="dialog"
    @keyup.esc.exact="clickConfirmHideForm"
  >
    <m-form :height="610">
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
          <div class="btn-close m__icon-close" @click="clickConfirmHideForm"></div>
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
                  v-model:errMsg="errors.EmployeeCode"
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
                  v-model:errMsg="errors.FullName"
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
                <MComboboxDepartment />
              </div>
            </div>
            <div class="left-3">
              <div class="group__input--title">
                <div class="input__title">Chức danh</div>
                <MInput v-model="employee.PostitionName" :class="['input-full-width']" />
              </div>
            </div>
          </div>
          <div class="grid__up-right row-3">
            <div class="right-1">
              <div class="group__input--title">
                <div class="input__title">Ngày sinh</div>
                <!-- <input type="date" class="input input-full-width" id="txtBirthday" /> -->
                <MInput
                  v-model="employee.DateOfBirth"
                  :type="'date'"
                  :classInput="['input-full-width']"
                />
              </div>
              <div class="group__input--title">
                <div class="input__title" style="margin-left: 5px">Giới tính</div>
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
                <MInput v-model="employee.IdentifyNumber" />
              </div>
              <div class="group__input--title">
                <div class="input__title">Ngày cấp</div>
                <MInput
                  v-model="employee.IdentifyDate"
                  :type="'date'"
                  :classInput="['input-full-width']"
                />
              </div>
            </div>
            <div class="right-3">
              <div class="group__input--title">
                <div class="input__title">Nơi cấp</div>
                <MInput
                  v-model="employee.IdentifyPlace"
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
              <MInput :classInput="['input-full-width']" />
            </div>
          </div>
          <div class="grid__down-2">
            <div class="group__input--title">
              <div class="input__title">ĐT di động</div>
              <MInput v-model:value="employee.PhoneNumber" />
            </div>
            <div class="group__input--title">
              <div class="input__title">ĐT cố định</div>
              <MInput />
            </div>
            <div class="group__input--title">
              <div class="input__title">Email</div>
              <MInput />
            </div>
          </div>
          <div class="grid__down-2 col-3">
            <div class="group__input--title">
              <div class="input__title">Tài khoản ngân hàng</div>
              <MInput />
            </div>
            <div class="group__input--title">
              <div class="input__title">Tên ngân hàng</div>
              <MInput />
            </div>
            <div class="group__input--title">
              <div class="input__title">Chi nhánh</div>
              <MInput />
            </div>
          </div>
        </div>
      </template>

      <template #footer>
        <div class="group__button-left">
          <MButton :classBtn="'button2'" :text="'Hủy'" @click="clickCancel" />
        </div>
        <div class="group__button-right">
          <MButton :classBtn="'button2 button__save'" :text="'Cất'" @click="clickAdd" />
          <MButton
            :classBtn="'button1'"
            :text="'Cất và thêm'"
            @click="clickAddEmployee"
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
/**
 * Bảng chi tiết thông tin nhân viên
 * Author : Locdx 13/09/2022
 */

export default {
  name: "EmployeeDetail",
  props: {
    isShowFormParent: {
      default: false,
    },
    employeeSelected: Function,
    formMode: {
      type: Number,
      default: 1,
    },
  },
  data() {
    return {
      messageError: "",
      employee: {},
      value: null,
      isShowPopup: false,
      listGender: [
        { Name: "Nam", Value: 0 },
        { Name: "Nữ", Value: 1 },
        { Name: "Khác", Value: 2 },
      ],
      errors: {},
    };
  },
  components: { MDialog, MButton, MCheckbox },
  created() {
    this.employee = this.employeeSelected;
  },
  mounted() {},
  methods: {
    // Thêm mới hoặc sửa nhân viên
    clickAddEmployee() {
      // validate dữ liệu
      if (!this.objectIsEmpty(this.errors)) {
        this.messageError = this.errors.EmployeeCode;
        if (this.messageError) {
          this.isShowPopup = true;
          return;
        }
      }

      // Cất dữ liệu
      // Thêm mới - formMode = 1
      // Sửa - formMode = 2
      if (this.formMode == 1) {
        HTTP.post(`/employees`, this.employee)
          .then((response) => {
            alert("thành công", response);
            this.$emit("hide-form");
          })
          .catch((error) => {
            console.log(error);
          });
      } else if (this.formMode == 2) {
        HTTP.put(`/employees/${this.employee.EmployeeId}`, this.employee)
          .then((res) => {
            alert(res);
            this.$emit("hide-form");
          })
          .catch();
      }
    },
    // Click button close sẽ có dialog
    clickHideForm() {
      this.$emit("hide-form");
    },
    clickConfirmHideForm() {
      this.$emit("confirm-form");
    },
    // Click Hủy sẽ đóng form nếu ko có thay đổi
    clickCancel() {
      this.$emit("hide-form", false);
    },
    objectIsEmpty(obj) {
      return (
        obj && // 👈 null and undefined check
        Object.keys(obj).length === 0 &&
        Object.getPrototypeOf(obj) === Object.prototype
      );
    },
  },
};
</script>

<style></style>
