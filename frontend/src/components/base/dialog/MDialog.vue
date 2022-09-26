<template>
  <div class="dialog">
    <div class="dialog__msg-box">
      <div class="msg-content">
        <div class="m__icon-question"></div>
        <div class="msg__content" style="margin-right: 20px">
           {{text}}
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
            @click="handleSuccess"
          >
            Có
          </button>
          <!-- <Mbutton :class="['button1']" :style="50" :text="'Co'"/> -->
        </div>
      </div>
    </div>
  </div>
</template>
<script>
  import MISAResource from '@/resource/resource';
export default {
  name: "MDialog",
  props: {
    formMode: 0,
  },
  created() {
    // set text cho cảnh báo
    if(this.formMode == 1 || this.formMode == 2 ) {
      this.text = MISAResource.MessageDialog.confirm["VI"]
    } else {
      this.text = MISAResource.MessageDialog.delete["VI"]
    }
  },
  methods: {
    /**
     * Ẩn dialog
     * Author: DXLOC 19/09/2022
     */
    clickHideDialog() {
      this.$emit("hide-dialog");
    },
    /**
     * Ẩn dialog và form
     * Author: DXLOC 19/09/2022
     */
    clickHideAll() {
      this.$emit("hide-all");
    },
    /**
     * Click "Có" sẽ xảy ra event
     * Author: DXLOC 19/09/2022
     */
    handleSuccess() {
        if(this.formMode == 1) {
          this.$emit("update-emp");
        } else {
          this.$emit("delete-emp");
        }
    }
  },
  data() {
    return {
    };
  },
};
</script>
<style>
@import url("@/css/components/dialog.css");
</style>
