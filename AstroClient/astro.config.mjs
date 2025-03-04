import { defineConfig } from 'astro/config';
import vue from '@astrojs/vue';

export default defineConfig({
  integrations: [vue()],
  server: {
    proxy: {
      '/api': {
        target: 'https://localhost:7139',
        changeOrigin: true,
        secure: false
      }
    }
  }
});