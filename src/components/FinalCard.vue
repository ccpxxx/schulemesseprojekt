<template>
    <div class="card-container border gap-2 pl-4 border-cyan-200 grid grid-cols-2">
        <div class="card-container__left flex p-4 justify-center rounded-full ">
            
                <img :src="obj.picture"
                class="moveIn h-full w-3/4 object-cover rounded-full" alt="user picture " />
           
        </div>
        <div class="card-container__right p-4">
            <div class="card-container__right__text border border-gray-800 rounded-sm">
                <h1 class="h-20 text-4xl">Name: {{ obj.name }}</h1>
                <h2 class="h-20 text-4xl" >ID: {{ obj.id }}</h2>
                <h2 class="h-20 text-4xl">ROLE: BLABLA</h2>
                <h2 class="h-20 text-4xl">ROLE: BLABLA</h2>
                <h2 class="h-20 text-4xl">ROLE: BLABLA</h2>
            </div>
    </div>
</div>

</template>

<script setup lang="ts">

const props = defineProps<{ obj: { id: string, name: string, picture: string } }>()
</script>

<style scoped>
    .moveIn {
        animation: moveIn 1.5s ease-out;
        opacity: 1;
    }
    @keyframes moveIn {
        0% {
            
            transform:  translateX(250px);
        }
        100% {
            
            transform: translateY(0);
        }
    }

</style>