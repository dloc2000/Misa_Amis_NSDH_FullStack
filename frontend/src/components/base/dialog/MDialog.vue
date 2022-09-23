<template>
  <div class="dialog">
    <div class="dialog__msg-box">
      <div class="msg-content">
        <div class="m__icon-question"></div>
        <div class="msg__content" style="margin-right: 20px">
          Dữ liệu đã bị thay đổi. Bạn có muốn cất không?
        </div>
      </div>
      <div class="dialog__footer">
        <MButton
          :class="['button2']"
          :style="75"
          :text="'Hủy'"
          @click="clickHideDialog"
        />
        <div class="">
          <MButton
            :class="['button2']"
            :style="75"
            :text="'Không'"
            @click="clickHideAll"
          />
          <button
            class="button button1"
            style="min-width: 50px !important; margin-left: 6px"
          >
            Có
          </button>
          <!-- <Mbutton :class="['button1']" :style="50" :text="'Co'"/> -->
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
    // Thông báo dữ liệu bị thay đổi
    layoutDataChange: [
      "m__icon-warning",
      "Bạn có thực sự muốn xóa Nhân viên không?",
    ],
    // Cảnh báo xóa nhân viên hay không
    layoutDataDelete: [
      "m__icon-question",
      "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
    ],
  },
  methods: {
    // Ẩn dialog
    clickHideDialog() {
      this.$emit("hide-dialog");
    },
    // Ẩn dialog và form
    clickHideAll() {
      this.$emit("hide-all");
    },
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
