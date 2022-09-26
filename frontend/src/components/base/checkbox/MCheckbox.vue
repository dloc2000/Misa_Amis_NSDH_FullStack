<template>
  <input
    :id="idCheckbox"
    class="m__checkbox-input"
    :class="{ 'checkbox-active': isActive }"
    type="checkbox"
    @click="clickCheckbox()"
    :value="modelValue"
    @change="$emit('update:modelValue', $event.target.value)"
  />
</template>
<script>
export default {
  name: "MCheckbox",
  props: {
    modelValue: {
        Type: String,
        default: ""
    },
    idCheckbox: {
      Type: String,
      default: null,
    },
  },
  data() {
    return {
      isActive: false,
    };
  },
  methods: {
    /**
     * Chọn checkbox
     * Author: DXLOC 20/09/2022
     */
    clickCheckbox() {
      this.isActive = !this.isActive;
    },
  },
};
</script>
<style scoped>
.m__checkbox-input {
  /* background: url(@/assets/img/Sprites.64af8f61.svg) no-repeat -1225px -363px;
  width: 14px;
  height: 11px; */
}
input[type="checkbox"] {
  /* tắt định dạng checkbox */
  appearance: none;
  -webkit-appearance: none;
  height: 20px;
  width: 20px;
  outline: none;
  background-color: #fff;
  border: 1px solid #ccc;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
}
.checkbox-active {
  border: 1px solid #2ca01c !important;
}
input[type="checkbox"]:after {
  content: "";
  font-weight: 700;
  font-size: 30px;
  background: url(@/assets/img/Sprites.64af8f61.svg) no-repeat -1294px -562px;
  width: 18px;
  height: 15px;
  /* transform: rotate(0deg); */
  display: none;
}
input[type="checkbox"]:checked:after {
  display: block;
  /* transition: all 0.2 ease;
  transform: rotate(-180deg); */
}
</style>
