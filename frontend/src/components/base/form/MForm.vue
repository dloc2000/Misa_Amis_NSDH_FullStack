<template>
  <div class="dialog__content">
    <div
      class="container__form"
      :style="{
        width: width ? width + 'px' : 'auto',
        height: height ? height + 'px' : 'auto',
      }"
    >
      <div class="container__form-header">
        <slot name="header"></slot>
      </div>
      <div class="container__form-body row-2">
        <slot name="content"></slot>
      </div>
      <div class="divide"></div>
      <div class="container__form-footer">
        <slot name="footer"></slot>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MForm",
  props: {
    width: {
      Type: [Number, String],
      default: null,
    },
    height: {
      Type: [Number, String],
      default: null,
    },
  },
  data() {
    return {};
  },
};
</script>
<style>
@import url(@/css/layout/formEmployee.css);
</style>
