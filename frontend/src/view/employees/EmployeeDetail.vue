<template>
  <div
    tabindex="0"
    id="formEmployee"
    class="dialog"
    @keyup.esc.exact="clickConfirmHideForm"
  >
    <div class="dialog__content">
      <div class="container__form">
        <div class="container__form-header">
          <div class="form__popup-title">
            <div class="title-popup">Thông tin nhân viên</div>
            <div class="checkbox__component">
              <input class="input-checkbox" type="checkbox" />
              <label for="">Là khách hàng</label>
            </div>
            <div class="checkbox__component">
              <input class="input-checkbox" type="checkbox" />
              <label for="">Là nhà cung cấp</label>
            </div>
          </div>
          <div class="form__popup-close">
            <div class="btn-help m__icon-help"></div>
            <div class="btn-close m__icon-close" @click="clickConfirmHideForm"></div>
          </div>
        </div>
        <div id="formBody" class="container__form-body row-2">
          <div class="form__grid-up col-2">
            <div class="grid__up-left row-3">
              <div class="left-1">
                <div class="group__input--title">
                  <div class="input__title">
                    Mã
                    <b style="color: red">*</b>
                  </div>
                  <input
                    type="text"
                    class="input"
                    v-model="employee.EmployeeCode"
                    ref="inputFocus"
                    :class="checkBlur(employee.EmployeeCode)"
                  />
                </div>
                <div class="group__input--title">
                  <div class="input__title">
                    Tên
                    <b style="color: red">*</b>
                  </div>
                  <input
                    type="text"
                    class="input"
                    v-model="employee.FullName"
                    :class="checkBlur(employee.FullName)"
                  />
                </div>
              </div>
              <div class="left-2">
                <div class="group__input--title">
                  <div class="input__title">
                    Đơn vị
                    <b style="color: red">*</b>
                  </div>
                  <div class="combobox">
                    <input type="text" class="input" />
                    <button>
                      <div class="m-arrow-dropdown"></div>
                    </button>
                    <div class="combobox__data" hidden>
                      <div class="combobox__item" value="0">Ban giám đốc</div>
                      <div class="combobox__item" value="1">Ban nhân sự</div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="left-3">
                <div class="group__input--title">
                  <div class="input__title">Chức danh</div>
                  <input
                    type="text"
                    class="input input-full-width"
                    id="txtPosition"
                    v-model="employee.PositionName"
                  />
                </div>
              </div>
            </div>
            <div class="grid__up-right row-3">
              <div class="right-1">
                <div class="group__input--title">
                  <div class="input__title">Ngày sinh</div>
                  <input type="date" class="input input-full-width" id="txtBirthday" />
                </div>
                <div class="group__input--title">
                  <div class="input__title">Giới tính</div>
                  <div>
                    <input type="radio" id="male" name="selector" />
                    <label for="male">Nam</label>
                    <input type="radio" id="female" name="selector" />
                    <label for="female">Nữ</label>
                    <input type="radio" id="other" name="selector" />
                    <label for="other">Khác</label>
                  </div>
                </div>
              </div>
              <div class="right-2">
                <div class="group__input--title">
                  <div class="input__title">Số CMND</div>
                  <input type="text" class="input" v-model="employee.PhoneNumber" />
                </div>
                <div class="group__input--title">
                  <div class="input__title">Ngày cấp</div>
                  <input type="date" class="input input-full-width" />
                </div>
              </div>
              <div class="right-3">
                <div class="group__input--title">
                  <div class="input__title">Nơi cấp</div>
                  <input type="text" class="input input-full-width" />
                </div>
              </div>
            </div>
          </div>
          <div class="form__grid-down row-3">
            <div class="grid__down-1">
              <div class="group__input--title">
                <div class="input__title">Địa chỉ</div>
                <input type="text" class="input input-full-width" />
              </div>
            </div>
            <div class="grid__down-2">
              <div class="group__input--title">
                <div class="input__title">ĐT di động</div>
                <input type="text" class="input" />
              </div>
              <div class="group__input--title">
                <div class="input__title">ĐT cố định</div>
                <input type="text" class="input" />
              </div>
              <div class="group__input--title">
                <div class="input__title">Email</div>
                <input type="text" class="input" />
              </div>
            </div>
            <div class="grid__down-2 col-3">
              <div class="group__input--title">
                <div class="input__title">Tài khoản ngân hàng</div>
                <input type="text" class="input" />
              </div>
              <div class="group__input--title">
                <div class="input__title">Tên ngân hàng</div>
                <input type="text" class="input" />
              </div>
              <div class="group__input--title">
                <div class="input__title">Chi nhánh</div>
                <input type="text" class="input" />
              </div>
            </div>
          </div>
        </div>
        <div class="divide"></div>
        <div class="container__form-footer">
          <div class="group__button-left">
            <MButton :classBtn="'button2'" :text="'Hủy'" @click="clickCancel" />
          </div>
          <div class="group__button-right">
            <MButton :classBtn="'button2 button__save'" :text="'Cất'" />
            <MButton
              :classBtn="'button1'"
              :text="'Cất và thêm'"
              @click="clickAddEmployee"
            />
          </div>
        </div>
      </div>
    </div>
    <MDialog v-if="false" />
  </div>
</template>

<script>
import MDialog from "@/components/base/dialog/MDialog.vue";
import MButton from "@/components/base/button/MButton.vue";
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
  created() {
    this.employee = this.employeeSelected;
  },
  mounted() {
    // focus ô input đầu tiên
    this.$refs.inputFocus.focus();
  },
  methods: {
    // Thêm mới nhân viên
    clickAddEmployee() {
      let url = "https://cukcuk.manhnv.net/api/v1/Employees";
      let method = "POST";
      // validate dữ liệu
      // Cất dữ liệu
      // Thêm mới - formMode = 1
      // Sửa - formMode = 2
      if (this.formMode == 2) {
        method = "PUT";
        url = url + "/" + `${this.employee.EmployeeId}`;
      }
      console.log("da click");
      fetch(url, {
        method: method,
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.employee),
      })
        .then((res) => res.json())
        .then((res) => {
          alert("thành công", res);
          this.$emit("hide-form");
        })
        .catch((error) => {
          console.log(error);
        });
    },
    // Click button close sẽ có dialog
    clickHideForm() {
      this.$emit("hide-form");
    },
    clickConfirmHideForm() {
      this.$emit("confirm-form");
    },
    // Click hủy sẽ đóng form nếu ko có thay đổi
    clickCancel() {
      this.$emit("hide-form-not-load-data");
    },
    checkBlur(data) {
      if (data == "" || data == null)
        return {
          "input--error": true,
        };
      else return "";
    },
  },
  data() {
    return {
      employee: {},
      inputFocus: undefined,
    };
  },
  components: { MDialog, MButton },
};
</script>

<style></style>
