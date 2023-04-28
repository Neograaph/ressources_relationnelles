/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/app/app.component.html",
    "./src/**/*.{html,ts}",
  ],
  theme: {
    colors: {
      transparent: 'transparent',
      current: 'currentColor',
      'bleufonce': '#092A3F',
      'blanc': '#F9F9F9',
    },
    extend: {},
  },
  plugins: [],
}
