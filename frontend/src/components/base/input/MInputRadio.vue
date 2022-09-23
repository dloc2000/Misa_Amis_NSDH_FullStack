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
  },
  methods: {
    onChange(value) {
      this.$emit("update:modelValue", value);
    },
  },
};
</script>
<style lang=""></style>
