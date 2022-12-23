<template>

<div class="flex flex-col gap-4 w-1/2 m-auto  items-center">
    <p class="mb-4">Nur 3 Klicks bis zu ihrem Messeausweis</p>
    <label for="name">Nachname</label>
    <input name="name" id="name" class="mb-4" type="text" v-model="props.obj!.name" />
    <div class="flex flex-row gap-4 ">

      <button  class="send p-4 bg-green-400 " @click="back">Back</button>
      <button  class="send p-4 bg-green-400" @click="next">Next</button>
    </div>
  </div>
  <div class="flex flex-col gap-4 w-1/2 m-auto">

   
  </div>
</template>


<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
import TabWrapper from '../components/TabWrapper.vue';
import TabVue from '../components/Tab.vue';
import UserObject from "../interfaces/UserObject";
import { castToVueI18n, I18nInjectionKey } from 'vue-i18n';
import { Ref } from 'vue';
import { triggerEvent } from '../utils/func';
const userObject: any = $ref({ id: '', name: '' });
let mode = $ref('dark')
const changeStyle = () => {
  mode = mode === 'dark' ? 'light' : 'dark'
}
// Siehe auch: https://vuejs.org/guide/extras/reactivity-transform.html 
const props = defineProps<{ obj?: UserObject }>()
const count = $ref(0)
const back = () => {
  triggerEvent(document.querySelector(".register"), "click")
}
const next = () => {
  triggerEvent(document.querySelector(".picture"), "click")
}
</script>