<template>
  <button
    :style="{ width: width + 'px' }"
    class="button"
    :class="classBtn"
    @click="clickBtn"
  >
    {{ text }}
  </button>
</template>
<script>
export default {
  name: "MButton",
  props: {
    classBtn: {
      Type: String,
      default: "button1",
    },
    width: {
      Type: Number,
      default: null,
    },
    text: {
      Type: String,
      default: "Click me",
    },
  },
  data() {
    return {};
  },
  methods: {
    clickBtn() {},
  },
};
</script>
<style>
@import url("@/css/components/button.css");
</style>
