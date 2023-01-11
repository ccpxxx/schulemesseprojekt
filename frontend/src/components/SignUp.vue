<template>
  <div class="flex flex-col gap-4 w-1/2 m-auto  items-center">
    <label for="prename" class="user__input">{{ $t('messe.prename') }}</label>
    <input name="prename" id="prename" class="mb-4" type="text" v-model="props.obj!.firstname" />
    <label for="lastname" class="user__input">{{$t("messe.name")}}</label>
    <input name="lastname" id="lastname" class="mb-4" type="text" v-model="props.obj!.name" />
    <button class="send p-4 bg-green-400 w-full" @click="toContact">{{ $t('messe.next') }}</button>
  </div>
</template>
<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
import TabWrapper from '../components/TabWrapper.vue';
import TabVue from '../components/Tab.vue';
import UserObject from "../interfaces/UserObject";
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
  if(!props.obj.firstname || !props.obj.name) {
    alert("Bitte alle Pflichtfelder ausfüllen")
    return
  }
  triggerEvent(document.querySelector(".contact"), "click")
}
</script>