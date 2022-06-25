import { Box, Grid, Link, Stack, TextField, Typography } from "@mui/material";
import React from "react";
import { Icon } from "@iconify/react";

function Title() {
  return (
    <Grid display={"flex"} direction={"column"} item xs={3}>
      <Box px={4} marginBottom={2}>
        {/* task header */}
        <Stack
          direction={"row"}
          justifyContent={"space-between"}
          fontSize={25}
          color={"#fff"}
        >
          {/* task title */}
          <Stack direction={"row"} alignItems="center" spacing={1}>
            <Icon icon="bx:box" />
            <Icon
              icon="codicon:circle-large-filled"
              fontSize={15}
              color="#c26060"
            />
            <Typography variant="h2">Task Title</Typography>
          </Stack>

          {/* task buttons */}
          <Stack direction={"row"} spacing={1}>
            <Icon icon="majesticons:image-circle" />
            <Icon icon="fluent:edit-24-regular" />
          </Stack>
        </Stack>

        {/* task body */}
        <Box color={"#fff"} marginTop={2}>
          <Typography variant="body1" fontWeight={600}>
            Description
          </Typography>
          <Typography variant="body1">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quia hic
            dolore eius tempore ratione minus modi laboriosam id, eaque
            blanditiis! Lorem ipsum dolor sit amet, consectetur adipisicing
            elit. Quia hic dolore eius tempore ratione minus modi laboriosam id,
            eaque blanditiis!
          </Typography>
        </Box>

        <Box color={"#fff"} marginTop={1}>
          <Typography variant="body1" fontWeight={600}>
            Link
          </Typography>
          <Link color={"#fff"} variant="body1">
            http://www.hello.com
          </Link>
        </Box>
      </Box>

      {/* message */}
      <Stack
        p={4}
        bgcolor={"#fff"}
        borderRadius={"20px 20px 0 0"}
        flexGrow={1}
        spacing={2}
      >
        {[1, 2, 3, 3, 33, 34].map((value) => {
          return (
            <Stack key={value + Math.random().toFixed(2)}>
              <Stack
                direction={"row"}
                alignItems="flex-end"
                spacing={1}
                color="#2f2f2f9b"
              >
                <Typography variant="body1">Name Arif</Typography>
                <Typography variant="caption">19/20/2002 13:22</Typography>
              </Stack>
              <Typography variant="body1" fontSize={16}>
                Message
              </Typography>
            </Stack>
          );
        })}
      </Stack>
      <Stack
        spacing={1}
        alignItems={"center"}
        direction={"row"}
        px={4}
        py={2}
        bgcolor={"#F5F5F5"}
      >
        <TextField
          hiddenLabel
          sx={{ flex: 1 }}
          id="filled-hidden-label-small"
          variant="standard"
          placeholder="Text here"
        />
        <Icon fontSize={25} icon="eva:attach-outline" />
        <Icon fontSize={25} icon="fluent:send-16-regular" />
      </Stack>
    </Grid>
  );
}

export default Title;
