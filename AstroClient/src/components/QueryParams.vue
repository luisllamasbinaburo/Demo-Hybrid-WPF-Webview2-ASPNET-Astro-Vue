<script setup >
import { ref, onMounted } from 'vue';

const params = ref({});
const data = ref(null);

onMounted(async () => {
  // Obtener parámetros de la URL
  const urlSearchParams = new URLSearchParams(window.location.search);
  params.value = Object.fromEntries(urlSearchParams.entries());

  // Hacer una petición a la API si hay un "id" en los parámetros
  if (params.value.id) {
    const response = await fetch(`/api/data?id=${params.value.id}`);
   
  }
  else {
    const response = await fetch(`http://localhost:5000/Files`);
    data.value = await response.json();
  }
});
</script>

<template>
  <div>
    <h2>Query Parameters</h2>
    <pre>{{ params }}</pre>

    <h2>Datos desde API</h2>
    <pre v-if="data">{{ data }}</pre>
    <p v-else>Cargando datos...</p>
  </div>
</template>
