import logo from "./logo.svg";
import "../Main.css";
import {
    Box,
    Stack,
    Grid,
    Typography,
    Link,
    Input,
    TextField,
    Button,
} from "@mui/material";
import { ui_colors } from "./theme";
import Title from "../components/Title";
import { Icon } from "@iconify/react";
import { useState } from "react";
import Tasks from "../components/Tasks";

export function Main() {
    return (
        <Box height={"100vh"} overflow="hidden" bgcolor={ui_colors.primary}>
            {/* nav */}
            <Stack
                direction={"row"}
                height={"120px"}
                justifyContent={"space-between"}
                boxSizing={"border-box"}
                px={4}
                py={6}
            >
                <Stack spacing={2} direction={"row"} alignItems={"center"} color="#fff">
                    <Icon fontSize={40} icon="icon-park-outline:oval-love-two" />
                    <Typography variant="h1">Calculator</Typography>
                    <Icon icon="ep:arrow-down-bold" />
                </Stack>
                <Stack spacing={2} direction={"row"} alignItems={"center"} color="#fff">
                    <Icon icon="gg:profile" fontSize={30} />
                    <Typography variant="h2">Lorenzo Bulosan</Typography>
                </Stack>
            </Stack>

            <Grid height={"calc(100% - 120px)"} container>
                <Tasks />
                <Title />
            </Grid>
        </Box>
    );
}

