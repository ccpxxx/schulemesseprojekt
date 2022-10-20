<template>
  <div class="relative overflow-hidden">
    <!-- small, blurry image. always loaded -->
    <picture>
      <source type="image/webp" :srcset="logo[0]">
      <source type="image/avfi" :srcset="logo[1]">
      <source type="image/jpeg" :srcset="logo[2]">
      <img :src="logo[2]" alt="" role="presentation" loading="eager" height="200"
        class="blur-sm pointer-events-none object-cover [height:200px]">
    </picture>

    <!-- full size image. lazy loaded -->
    <picture>
      <source type="image/webp" :srcset="logo[3]">
      <source type="image/avfi" :srcset="logo[4]">
      <source type="image/jpeg" :srcset="logo[5]">
      <img :src="logo[5]" alt="logo" loading="lazy" height="200"
        class="z-10 bg-transparent opacity-5 transition-opacity pointer-events-none motio object-cover absolute top-0 left-0 [height:200px]"
        @load="imgLoaded">
    </picture>
  </div>
  <HelloWorld :msg="$t('headline')" />
</template>

<script setup lang="ts">
// @ts-ignore
import logo from "./assets/logo.png?h=100;200&format=webp;avfi;png"

function imgLoaded(ev: Event) { (ev.target as HTMLImageElement).style.opacity = '100' }
</script>