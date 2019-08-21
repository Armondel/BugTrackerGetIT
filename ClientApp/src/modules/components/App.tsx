import CssBaseline from "@material-ui/core/CssBaseline";
import * as React from "react";

import PageLayout from "./PageLayout";

const App: React.FC = () => {
	return (
		<div>
			<CssBaseline />
			<PageLayout />
		</div>
	);
};

export default App;
