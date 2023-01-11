<template>
  <div class="nav" v-if="admin">
    <router-link to="/admin">{{ $t('adminpanel') }}</router-link>
  </div>
  <div class="flex  w-full justify-start items-start">
    <button class="login-button  border-2" @click="login" v-if="!admin">Login</button>
    <!-- logout button-->
    <button class="login-button  border-2" @click="logout" v-if="admin">Logout</button>
  </div>
  <dialog ref="popupDialog">
  <div class="dialog-container flex flex-col gap-2">
    <label>Name</label>
    <input v-model="username" type="text" />
    <label>Password</label>
    <input v-model="password" type="password" />
    <button @click="submit" @keyup.enter.native="submit">Login</button>
  </div>
  </dialog>
  <header class="header bg-slate-300 w-full sticky">
    <div class="flex flex-row  items-center justify-center">
      <div class="w-1/3 pl-8">
      <img src="./assets/logo.png" alt="Logo" class="logo " />
      </div>
      <div class="w-2/3 flex flex-col justify-center items-center">
        <h1 class="text-4xl font-bold text-center">{{$t("introduction")}}</h1>
        <h2 class="text-2xl font-bold text-center">{{ $t('hier-koennen-sie-ein-foto-von-sich-machen-und-im-anschluss-direkt-ausdrucken-lassen-samt-initialiten') }}</h2>
        <button class="self-center flex gap-1" @click="i18n.global.locale.value == 'en' ? i18n.global.locale.value ='de' : i18n.global.locale.value ='en'"><img class="h-12 w-12" :src="i18n.global.locale.value == 'en' ? flagDE : flagUK"><p class=" text-4xl">{{i18n.global.locale.value == 'en' ? 'DE' : 'EN'}}</p></button>
      </div>
    </div>
  </header>
  <RouterView />
</template>

<script setup lang="ts">
// @ts-ignore
import logo from "./assets/logo.png?h=100;200&format=webp;avfi;png"
import { i18n } from "./main";
import flagDE from "./assets/flag-germany.svg";
import flagUK from "./assets/flag-united-kingdom.svg";
let admin = $ref(false)
let username = $ref('')
let password = $ref('')
const popupDialog = $ref(null)
function imgLoaded(ev: Event) { (ev.target as HTMLImageElement).style.opacity = '100' }
function login() { 
  popup = !popup
  popupDialog!.showModal()
}

function submit() {
  if(username == import.meta.env.VITE_USERNAME && password == import.meta.env.VITE_PASSWORD) {
    admin = !admin
    popup = !popup
    localStorage.setItem("loggedUser", "true")
    popupDialog!.close()
    alert("Successfully logged in")
    return
  }
  alert('Wrong credentials')
}
function logout() {
  admin = !admin
  alert("Successfully logged out")
}
let popup = $ref(false)
console.log(import.meta.env.VITE_USERNAME, "USER")
</script>

<style>
dialog::backdrop {
  background-color: rgba(0, 0, 0, 0.5);
}

</style>