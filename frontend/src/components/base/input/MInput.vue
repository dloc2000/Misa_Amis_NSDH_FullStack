<template>
  <input :type="type" v-model="value" class="input" />
</template>
<script>
import MBaseControlVue from "@/components/MBaseControl.vue";

export default {
  extends: MBaseControlVue,
  name: "MInput",
  props: {
    width: {
      Type: [Number, String],
      default: 100,
    },
    type: {
      Type: String,
      default: "text",
    },
    value: {
      Type: String,
      default: null,
    },
    rules: {
      Type: String,
      default: null,
    },
  },
  data() {
    return {
      currentValue: this.value,
      isValidate: false,
    };
  },
  watch: {
    value: {
      handler(newVal, oldVal) {
        if (newVal != oldVal) {
          this.$emit("update-value", newVal);
        }
      },
    },
  },
  methods: {
    validateControl() {
      if (this.rules && this.rules.length > 0) {
        let listRules = this.rules.split(";");
        listRules.forEach((rule) => {
          if (rule == "required") {
            if (!this.value) {
              this.isValidate = true;
            }
          } else if (rule == "email") {
            // Email đúng định dạng
          }
        });
      }
    },
  },
};
</script>
<style>
@import url("@/css/components/input.css");
</style>
