import globals from 'globals'
import js from '@eslint/js'
import tseslint from 'typescript-eslint'
import { defineConfig } from 'eslint/config'

export default defineConfig([
    {
        files: ['**/*.{js,mjs,cjs,ts,mts,cts}'], plugins: { js }, extends: ['js/recommended'], languageOptions: { globals: globals.browser },
        rules: {
            '@typescript-eslint/no-explicit-any': 'off',
            quotes: ['warn', 'single'],
            semi: ['warn', 'never']
        }
    },
    { files: ['**/*.js'], languageOptions: { sourceType: 'script' } },
    tseslint.configs.recommended,
])