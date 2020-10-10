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
    maxHeight: {
      '0': '0',
      '1': '1rem',
      '2': '2rem',
      '4': '4rem',
      '8': '8rem',
      '16': '16rem',
      '1/4': '25%',
      '1/2': '50%',
      '3/4': '75%',
      'full': '100%'
    },
    extend: {},
  },
  variants: {},
  plugins: [],
  future: {
    removeDeprecatedGapUtilities: true,
  }
};
