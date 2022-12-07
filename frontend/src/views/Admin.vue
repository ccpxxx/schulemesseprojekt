<template>
    <div class="nav">
      <router-link to="/">Home</router-link>
    </div>
    <main class="bla">
        <h1>Admin</h1>
        <p>Admin page</p> 
    </main>
    <!-- <HelloWorld :msg="$t('headline')" /> -->
  </template>
  
  <script setup lang="ts">
  // @ts-ignore
  import logo from "./assets/logo.png?h=100;200&format=webp;avfi;png"
  
  function imgLoaded(ev: Event) { (ev.target as HTMLImageElement).style.opacity = '100' }
  </script>