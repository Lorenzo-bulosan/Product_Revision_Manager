import { Icon } from "@iconify/react";
import { Button, Grid, Stack, Typography } from "@mui/material";
import React, { useState } from "react";
import { ui_colors } from "../theme";

export default function Tasks() {
  const [active, setActive] = useState(0);
  return (
    <Grid
      height={"100%"}
      borderRadius={"20px 20px 0 0"}
      bgcolor={"#F5F5F5"}
      item
      xs={9}
      p={4}
    >
      <Stack height={"100%"} justifyContent={"space-between"}>
        <Grid container>
          {/* revision 1 */}
          <Grid item xs={4} px={2}>
            <Typography marginBottom={3} variant="h2">
              Revision 1
            </Typography>
            <Button variant="text">
              <Icon icon="akar-icons:plus" />
              Add new task
            </Button>
            <Stack spacing={1} marginLeft={-2} marginTop={1}>
              {[1, 2, 2].map((value, i) => {
                return (
                  <Stack
                    py={1}
                    direction={"row"}
                    alignItems={"center"}
                    sx={{
                      cursor: "pointer",
                      ":hover": active !== i && { bgcolor: "#fff" },
                    }}
                    bgcolor={active === i && ui_colors.primary}
                    color={active === i && "#fff"}
                    borderRadius={1}
                    px={2}
                    justifyContent={"space-between"}
                  >
                    <Stack direction={"row"} alignItems={"center"} spacing={1}>
                      <Icon
                        icon="codicon:circle-large-filled"
                        fontSize={15}
                        color="#c26060"
                      />
                      <Typography variant="h5">Hello world</Typography>
                    </Stack>
                    {active === i && <Icon icon="akar-icons:eye" />}
                  </Stack>
                );
              })}
            </Stack>
          </Grid>

          {/* revision 2 */}

          <Grid item xs={4} px={2}>
            <Typography marginBottom={3} variant="h2">
              Revision 1
            </Typography>
            <Button variant="text">
              <Icon icon="akar-icons:plus" />
              Add new task
            </Button>
            <Stack spacing={1} marginLeft={-2} marginTop={1}>
              {[1, 2, 2].map((value, i) => {
                return (
                  <Stack
                    py={1}
                    direction={"row"}
                    alignItems={"center"}
                    sx={{
                      cursor: "pointer",
                      ":hover": active !== i && { bgcolor: "#fff" },
                    }}
                    bgcolor={active === i && ui_colors.primary}
                    color={active === i && "#fff"}
                    borderRadius={1}
                    px={2}
                    justifyContent={"space-between"}
                  >
                    <Stack direction={"row"} alignItems={"center"} spacing={1}>
                      <Icon
                        icon="codicon:circle-large-filled"
                        fontSize={15}
                        color="#c26060"
                      />
                      <Typography variant="h5">Hello world</Typography>
                    </Stack>
                    {active === i && <Icon icon="akar-icons:eye" />}
                  </Stack>
                );
              })}
            </Stack>
          </Grid>

          {/* revision 3 */}
          <Grid item xs={4} px={2}>
            <Typography marginBottom={3} variant="h2">
              Revision 1
            </Typography>
            <Button variant="text">
              <Icon icon="akar-icons:plus" />
              Add new task
            </Button>
            <Stack spacing={1} marginLeft={-2} marginTop={1}>
              {[1, 2].map((value, i) => {
                return (
                  <Stack
                    py={1}
                    direction={"row"}
                    alignItems={"center"}
                    sx={{
                      cursor: "pointer",
                      ":hover": active !== i && { bgcolor: "#fff" },
                    }}
                    bgcolor={active === i && ui_colors.primary}
                    color={active === i && "#fff"}
                    borderRadius={1}
                    px={2}
                    justifyContent={"space-between"}
                  >
                    <Stack direction={"row"} alignItems={"center"} spacing={1}>
                      <Icon
                        icon="codicon:circle-large-filled"
                        fontSize={15}
                        color="#c26060"
                      />
                      <Typography variant="h5">Hello world</Typography>
                    </Stack>
                    {active === i && <Icon icon="akar-icons:eye" />}
                  </Stack>
                );
              })}
            </Stack>
          </Grid>
        </Grid>
        <Stack alignItems={"flex-end"}>
          <Button variant="text">
            <Stack spacing={1} alignItems="flex-start" direction={"row"}>
              <Icon fontSize={22} icon="akar-icons:cart" />
              <p>Unlock more revision</p>
            </Stack>
          </Button>
        </Stack>
      </Stack>
    </Grid>
  );
}
