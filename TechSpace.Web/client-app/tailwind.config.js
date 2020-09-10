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
      gray: {
        ...colors.gray,
        700: '#444444',
        800: '#222222'
      }
    },
    extend: {},
  },
  variants: {},
  plugins: [],
  future: {
    removeDeprecatedGapUtilities: true,
  }
};
