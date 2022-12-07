<template>
  <div class="nav" v-if="admin">
    <router-link to="/admin">Adminpanel</router-link>
  </div>
  <header class="header bg-slate-300 w-full sticky">
    <div class="flex flex-row  items-center justify-center">
      <div class="w-1/3 pl-8">
      <img src="./assets/logo.png" alt="Logo" class="logo " />
      </div>
      <div class="w-2/3 flex flex-col justify-center items-center">
        <h1 class="text-4xl font-bold text-center">{{$t("introduction")}}</h1>
        <h2 class="text-2xl font-bold text-center">Hier können sie ein Foto von sich machen und im Anschluss direkt ausdrucken lassen samt initialiten</h2>
        <button class="self-center flex gap-1" @click="i18n.global.locale.value == 'en' ? i18n.global.locale.value ='de' : i18n.global.locale.value ='en'"><img class="h-12 w-12" :src="i18n.global.locale.value == 'en' ? flagDE : flagUK"><p class=" text-4xl">{{i18n.global.locale.value == 'en' ? 'DE' : 'EN'}}</p></button>

      </div>
    </div>
  </header>
  <RouterView />
  <!-- <HelloWorld :msg="$t('headline')" /> -->
</template>

<script setup lang="ts">
// @ts-ignore
import logo from "./assets/logo.png?h=100;200&format=webp;avfi;png"
import { i18n } from "./main";
import flagDE from "./assets/flag-germany.svg";
import flagUK from "./assets/flag-united-kingdom.svg";
const admin = $ref(false)
function imgLoaded(ev: Event) { (ev.target as HTMLImageElement).style.opacity = '100' }
</script>