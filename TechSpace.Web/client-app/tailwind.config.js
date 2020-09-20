const { colors } = require('tailwindcss/defaultTheme')

module.exports = {
  purge: [
    "src/**/*.js",
    "src/**/*.jsx",
    "src/**/*.ts",
    "src/**/*.tsx",
    "public/**/*.html",
  ],
  theme: {
    colors: {
      ...colors,
      primary: colors.white,
      secondary: {
        light: '#201c2b',
        default: '#201c2b',
        dark: '#191523',
      },
    },
    extend: {},
  },
  variants: {},
  plugins: [],
  future: {
    removeDeprecatedGapUtilities: true,
  }
};
