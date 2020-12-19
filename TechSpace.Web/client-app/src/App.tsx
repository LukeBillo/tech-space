import React, { FunctionComponent } from "react";
import { ProvideSpaces } from './hooks/spaces.context';
import { HomePage } from "./components/home-page/home-page.component";

import './tailwind.output.css';

const App: FunctionComponent = () => {
  return (
			<ProvideSpaces>
        <HomePage />
			</ProvideSpaces>
  );
}

export default App;
