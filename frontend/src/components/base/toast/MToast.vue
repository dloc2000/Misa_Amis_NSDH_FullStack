<template>
    <div class="toast" :class="{'active' : modelValue}" v-if="modelValue">
            <div class="toast__message-dialog">
                <div class="toast__message-left">
                    <div class="toast__icon m__icon-success"></div>
                    <div class="toast__title">Thành công</div>
                </div>
                <div class="toast__message-right">
                    <div class="toast__close toast__success m__icon-close"></div>
                </div>
                <div class="progress" :class="{'active' : modelValue}"></div>
            </div>
    </div>
</template>
<script>
export default {
    name: "MToast",
    props: {
        modelValue: {
        Type: Boolean,
        default: false
       }
    },
    computed: {

    },
    watch: {
        // Timeout toast 3s
        modelValue(newval ,oldval) {
            if(newval == true) {
                setTimeout(() => {
                    this.$emit("update:modelValue" , !newval);
                }, 3000)
            }
        }
    },
    data() {
        return {
            
        }
    },
    methods: {
        
    },
}
</script>
<style>
    @import url('@/css/components/toastmessage.css');
</style>