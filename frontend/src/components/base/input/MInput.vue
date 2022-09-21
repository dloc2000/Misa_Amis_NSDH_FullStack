<template>
  <!-- <div> -->
  <input
    :type="type"
    :value="modelValue"
    ref="input"
    class="input"
    :class="{ 'input-required': errMsg }"
    @blur="blurInput(rules)"
    @input="onInput()"
    @change="onChange($event)"
    :title="errMsg"
  />
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
    modelValue: {
      Type: String,
      default: null,
    },
    rules: {
      Type: String,
      default: null,
    },
    classInput: {
      Type: String,
      default: null,
    },
    activeValidate: {
      Type: Number,
      default: 0,
    },
    errMsg: {
      type: String,
      default: "",
    },
    fieldName: {
      type: String,
      default: "",
    },
    firstFocus: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      currentValue: this.value,
      errorClass: "input-required",
    };
  },
  created() {
    // this.$bus.on("validate", (param) => {
    //   console.log(param);
    //   this.validateControl();
    // });
  },
  destroyed() {
    // this.$bus.off("validate");
  },
  mounted() {
    // autofocus
    if (this.firstFocus) {
      this.$refs.input.focus();
    }
  },
  methods: {
    /** */
    
    validateControl() {
      if (this.rules && this.rules.length > 0) {
        let listRules = this.rules.split(";");
        listRules.forEach((rule) => {
          if (rule == "required") {
            if (!this.modelValue) {
              if (this.fieldName) {
                this.$emit(
                  "update:errMsg",
                  this.fieldName + " không được để trống."
                );
              } else {
                this.$emit("update:errMsg", "Không được để trống.");
              }
            }
          } else if (rule == "email") {
            // Email đúng định dạng
          }
        });
      }
    },
    blurInput() {
      this.validateControl();
    },
    onChange(e) {
      this.$emit("update:modelValue", e.target.value);
    },
    onInput() {
      this.$emit("update:errMsg", null);
    },

  },
};
</script>
<style>
@import url("@/css/components/input.css");
</style>
