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
            noir: "#1c1c1c",
            grisclair: "#E1E8F2",
            violetbtn: "#2c338e",
            // "background-gris": "C9B3B3",
        },
        extend: {
            backgroundImage: {
                "custom-inscription": "url('src/assets/img/bg-inscription.png')",
                "custom-connexion": "url('src/assets/img/bg-connexion.png')",
            },
        },
    },
    plugins: [],
};
