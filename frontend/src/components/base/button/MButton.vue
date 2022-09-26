<template>
  <button :style="{ width: width + 'px' }" class="button" :class="classBtn" v-bind="$attrs">
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
};
</script>
<style>
@import url("@/css/components/button.css");
</style>
