<template>
  <div class="dialog">
    <div class="dialog__msg-box">
      <div class="msg-content">
        <div class="m__icon-warning"></div>
        <div class="msg__content" style="margin-right: 20px">
          Bạn có thực sự muốn xóa Nhân viên không?
        </div>
      </div>
      <div class="dialog__footer">
        <button class="button button2">Hủy</button>
        <div class="">
          <button class="button button2" style="width: 75px">Không</button>
          <button
            class="button button1"
            style="min-width: 50px !important; margin-left: 6px"
          >
            Có
          </button>
        </div>
      </div>
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
      this.$emit("hide-dialog");
    },
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
@import url("@/css/components/dialog.css");
</style>
