import * as React from "react";

import Container from "@material-ui/core/Container";
import AppBar from "@material-ui/core/AppBar";
import Typography from "@material-ui/core/Typography";
import Toolbar from "@material-ui/core/Toolbar";

const PageLayout: React.FC = () => {
	return (
		<Container fixed>
			<AppBar position="static" color="default">
				<Toolbar>
					<Typography variant="h6" color="inherit">
						Brand new shitty app
					</Typography>
				</Toolbar>
			</AppBar>
			<div />
		</Container>
	);
};

export default PageLayout;
