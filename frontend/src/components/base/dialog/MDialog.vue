<template>
  <div class="dialog">
    <div class="dialog__msg-box">
      <div class="msg-content">
        <div :class="listDataDialog[this.dialogSelected].classIcon"></div>
        <div class="msg__content" style="margin-right: 20px">
          <!-- Dữ liệu đã bị thay đổi. Bạn có muốn cất không? -->
          {{listDataDialog[this.dialogSelected].textContent}}
        </div>
      </div>
      <div class="footer">
        <button class="button2" style="width: 75px" @click="clickHideDialog">Không</button>
        <button class="button1" style="min-width: 50px !important">
          Có
        </button>
      </div>
    </div>

    <!-- <div class="dialog">
      <div class="dialog__msg-box">
          <div class="msg-content">
              <div class="m__icon-question"></div>
              <div class="msg__content" style="margin-right: 20px;">{{text}}</div>
          </div>
          <div class="footer">
              <button class="button2" style="width: 75px" id="btnCancel">Không</button>
              <button class="button1" style="min-width: 50px !important">Có</button>
          </div>
      </div>
  </div> -->
  </div>
</template>
<script>
export default {
  name: "MDialog",
  props: {
    // Chọn dialog lúc xóa hay lúc nhấn close
    dialogSelected: {
      default: 1,
    },
  },
  methods: {
    // Ẩn dialog
    clickHideDialog() {
      this.$emit('hide-dialog')
    }
    // Chọn dialog

  },
  data() {
    return {
      listDataDialog: [
        {
          classIcon: "m__icon-warning",
          textContent: "Bạn có thực sự muốn xóa Nhân viên không?",
        },
        {
          classIcon: "m__icon-question",
          textContent: "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
        },
      ],
    };
  },
};
</script>
<style>
.dialog__msg-box {
  display: flex;
  position: absolute;
  flex-direction: column;
  justify-content: space-between;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  border-radius: 4px;
  box-sizing: border-box;
  background-color: #fff;
  width: 444px;
  min-width: 400px;
  height: 182px;
  padding: 32px;
}

.dialog__msg-box .msg-content {
  display: flex;
  align-items: center;
  justify-content: space-around;
  padding-bottom: 20px;
  border-bottom: 1px solid #ccc;
}

.dialog__msg-box .footer {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>
