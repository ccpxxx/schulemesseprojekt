<template>
    PictureUpload
    {{obj}}
</template>

<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
import TabWrapper from '../components/TabWrapper.vue';
import TabVue from '../components/Tab.vue';
import UserObject from "../interfaces/UserObject";
import { castToVueI18n, I18nInjectionKey } from 'vue-i18n';
import { Ref } from 'vue';
const userObject: any = $ref({ id: '', name: '' });
let mode = $ref('dark')
const changeStyle = () => {
  mode = mode === 'dark' ? 'light' : 'dark'
}
// Siehe auch: https://vuejs.org/guide/extras/reactivity-transform.html 
const props = defineProps<{ obj?: UserObject }>()
const count = $ref(0)
</script>