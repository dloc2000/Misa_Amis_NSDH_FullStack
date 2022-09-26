<template>
  <!-- <div> -->
  <input :type="type" :value="modelValue" ref="input" class="input" :class="{ 'input-required': errMsg }"
    @blur="blurInput(rules)" @input="onInput($event)" @change="onChange($event)" :title="errMsg" />
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
      errorClass: "input-required",
    };
  },
  created() {
    
  },
  computed: {
    
  },
  watch: {
     /**
     * Bắt watch thay đổi dữ liệu trên input
     * Author : DXLoc 20/09/2022
     * 
     */
      modelValue(newval, oldval) {
        if (this.type == 'date' && newval != oldval) {
          this.$emit("update:modelValue", newval);
          // this.sliceString(newval)
        } 
      }
    
  },
  mounted() {
     /**
     * Auto focus ô nhập liệu đầu tiên khi mở form
     * Author : DXLoc 20/09/2022
     * 
     */
    if (this.firstFocus) {
      this.$refs.input.focus();
    }
  },
  methods: {
    /**
     * Validate dữ liệu khi người dùng để trống trường bắt buộc
     * Author : DXLoc 20/09/2022
     * 
     */
    validateControl() {
      if (this.rules && this.rules.length > 0) {
        // Danh sách các rules cần validate
        let listRules = this.rules.split(";");
        listRules.forEach((rule) => {
          if (rule == "required") {
            if (!this.modelValue) {
              // kiểm tra fieldName
              if (this.fieldName) {
                // bắn lỗi lên form
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
     /**
     * Blur ra ngoài sẽ chạy validate
     * Author : DXLoc 20/09/2022
     * 
     */
    blurInput() {
      this.validateControl();
    },
     /**
     * Binding 2 chiều dữ liệu
     * Author : DXLoc 20/09/2022
     * 
     */
    onChange(e) {
      this.$emit("update:modelValue", e.target.value);
    },
     /**
     * Validate khi có dữ liệu sẽ ko còn cảnh báo
     * Author : DXLoc 20/09/2022
     * 
     */
    onInput(e) {
      this.$emit("update:errMsg", null);
      this.$emit("update:modelValue", e.target.value);
    },
     /**
     * format date khi đẩy lên database
     * Author : DXLoc 21/09/2022
     * 
     */
    sliceString(text) {
        return text.slice(0,10) + "T00:00:00";
    }
   
  },
};
</script>
<style>
@import url("@/css/components/input.css");
</style>
