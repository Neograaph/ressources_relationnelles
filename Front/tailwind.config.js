/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/app/app.component.html", "./src/**/*.{html,ts}"],
  theme: {
    colors: {
      transparent: "transparent",
      current: "currentColor",
      bleufonce: "#092A3F",
      blanc: "#F9F9F9",
      "background-classic": "#DEDEDE",
      "background-panel": "#EFEFEF",
      rouge: "#730217",
      gris: "#747474",
      bleubtn: "#0A3A5B",
    },
    extend: {
      backgroundImage: {
        "custom-inscription": "url('src/assets/img/bg-inscription.png')",
      },
    },
  },
  plugins: [],
};
