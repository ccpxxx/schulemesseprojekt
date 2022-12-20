<template>
    <div class="flex justify-center items-center gap-4">
        <div class="pseudo-container overflow-hidden h-[429px] w-[429px] rounded-full bg-slate-200">
            <img class="picture  object-cover" :src="xaxa" />
        </div>
        <button @click="back">Back</button>
        <button @click="emitting">Emit</button>
    </div>
</template>

<script setup lang="ts">
import xaxa from "../assets/xaxa123.jpg"
import { triggerEvent } from "../utils/func";
const emit = defineEmits<(event: string, value: string) => void>()
const emitting = () => {
    emit('picture', xaxa)
}
const back = () => {
    triggerEvent(document.querySelector(".contact"), "click")
}
</script>

<style scoped>


</style>
