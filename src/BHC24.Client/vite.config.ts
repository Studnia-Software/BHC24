import {defineConfig} from 'vite'
import react from '@vitejs/plugin-react-swc'
import million from 'million/compiler'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [million.vite({auto: true}), react()],
    server: {
        proxy: {
            '/api': {

                target: 'https://localhost:7113/api',

                changeOrigin: true,
                rewrite: (path) => path.replace(/^\/api/, '')
            }
        }
    }
})
