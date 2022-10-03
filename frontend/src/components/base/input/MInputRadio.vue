<template lang="">
  <div class="input-radio d-flex">
    <div
      class="input-radio__item d-flex m-r-10"
      v-for="(item, index) in listOptions"
      :key="index"
    >
      <label :for="fieldName + index">{{ item.Name }}</label>
      <input
        type="radio"
        :name="fieldName"
        :value="item.Value"
        :checked="modelValue == item.Value"
        @change="onChange(item.Value)"
        :id="fieldName + index"
      />
    </div>
  </div>
</template>
<script>
export default {
  name: "MInputRadio",
  props: {
    fieldName: {
      type: String,
      default: "",
    },
    listOptions: {
      type: Array, // {Name: 'Nam', Value: 0}
      default: [],
    },
    modelValue: {
      type: [Number, String],
      default: "",
    },
    cloneGender: {
      type: Number,
      default: 0
    }
    
  },
  mounted() {
  },
  data() {
    return {
      
    }
  },
  methods: {
    /**
     * Sự kiện onchange update lại value
     * Author: DXL 20/09/2022
     */
    onChange(value) {
      this.$emit("update:modelValue", value);
    },
    // onInput(e) {
    //   this.$emit("update:modelValue" ,e.target.value)
    // }
  },
};
</script>
<style scoped>

input[type="radio"] {
  height: 1rem;
  width: 1rem;
  margin-right: 0.5rem;
  margin-top: 0;
  text-align: center;
  vertical-align: middle;
  appearance: none;
  -webkit-appearance: none;
  border: 0.2rem solid #fff;
  background-color: #e8e8e8;
  border-radius: 50%;
  box-shadow: 0 0 0 1px #bbbbbb;
}

input[type="radio"]:focus-visible, input[type="checkbox"]:focus-visible {
    outline-offset: 0;

}

input[type="radio"]:checked:checked {
    box-shadow: 0 0 0 1px #2ca01c;
    background-color: #2ca01c;
    border-width: 0.2rem;
}
</style>
