<template>
  <div class="flex flex-col gap-4">

    <p>Vorname</p><input type="text" v-model="props.obj!.name" />
    <p>Nachname</p><input type="text" />
    <p>Email</p><input type="text"  />
    <p>Rolle</p><input type="text"  />
    <button class="send" @click="toContact">Next</button>
  </div>
</template>
<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
import TabWrapper from '../components/TabWrapper.vue';
import TabVue from '../components/Tab.vue';
import UserObject from "../interfaces/UserObject";
import { castToVueI18n, I18nInjectionKey } from 'vue-i18n';
import { triggerEvent } from '../utils/func';
import { Ref } from 'vue';
const userObject: any = $ref({ id: '', name: '' });
let mode = $ref('dark')
const changeStyle = () => {
  mode = mode === 'dark' ? 'light' : 'dark'
}
// Siehe auch: https://vuejs.org/guide/extras/reactivity-transform.html 
const props = defineProps<{ obj?: UserObject }>()
const name = $ref(props.obj?.name)
const count = $ref(0)

function toContact() {
  triggerEvent(document.querySelector(".contact"), "click")
}
</script>