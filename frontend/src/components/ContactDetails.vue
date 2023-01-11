<template>

<div class="flex flex-col gap-4 w-1/2 m-auto  items-center">
    <label for="name">{{ $t('messe.address') }}</label>
    <input name="name" id="name" class="mb-4 w-full" type="text" v-model="props.obj!.address" />
    <label for="offical">{{$t("messe.official")}}</label>
    <input type="checkbox" v-model="props.obj!.isOfficial" />
    <label for="select">{{ $t('messe.interest') }}</label>
    <select multiple v-model="props.obj!.interests" name="select" class="w-3/4 gap-4 flex m-4 h-full p-2">
      <option value="Firmenkunde">{{ $t('messe.official') }}</option>
      <option value="Messezubehör">{{ $t('messe.accessory') }}</option>
      <option value="Haustierzubehör">{{ $t('messe.pet') }}</option>
      <option value="Hobbysammler">{{ $t('messe.hobby') }}</option>
    </select>
    <div class="flex flex-row gap-4 ">

      <button  class="send p-4 bg-green-400 " @click="back">{{ $t('messe.back') }}</button>
      <button  class="send p-4 bg-green-400" @click="next">{{ $t('messe.next') }}</button>
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
const select =  $ref("")
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