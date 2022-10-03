<template>
    <div class="dialog">
      <div class="dialog__msg-box">
        <div class="msg-content">
          <div class="m__icon-question"></div>
          <div class="msg__content" style="margin: 0 20px;">
             {{text}}
          </div>
        </div>
        <div class="dialog__footer">
          <MButton
            :class="'button2'"
            :style="75"
            :text="'Hủy'"
            @click="clickHideDialog"
          />
          <div class="">
            <MButton
              :class="'button2'"
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
          </div>
        </div>
      </div>
    </div>
  </template>
  <script>
  import MISAResource from '@/resource/resource';
  export default {
    name: "MDialogs",
    props: {
      formMode: 0,
    },
    created() {
    },
    methods: {
      /**
       * Ẩn dialog
       * Author: DXLOC 19/09/2022
       */
      clickHideDialog() {
        this.$emit("hide-dialogs");
      },
      /**
       * Ẩn dialog và form
       * Author: DXLOC 19/09/2022
       */
      clickHideAll() {
        this.$emit("hide-alls");
      },
      /**
       * Click "Có" sẽ xảy ra event
       * Author: DXLOC 19/09/2022
       */
      handleSuccess() {
          this.$emit("delete-all", this.employeesDelete)
      }
    },
    data() {
      return {
        text: MISAResource.MessageDialog.deletes["VI"],
        employeesDelete: []
      };
    },
  };
  </script>
  <style>
  @import url("@/css/components/dialog.css");
  </style>
  